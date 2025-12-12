// <copyright file="RootPerUserAccountDirectoryQuery.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System.IO;
using System.Security.Claims;

using FubarDev.FtpServer.AccountManagement.Directories;
using FubarDev.FtpServer.AccountManagement.Directories.RootPerUser;
using FubarDev.FtpServer.FileSystem;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FubarDev.FtpServer
{
    /// <summary>
    /// A single root directory per user.
    /// </summary>
    public class RootPerUserAccountDirectory : IAccountDirectoryQuery
    {
        private readonly ILogger<RootPerUserAccountDirectory> _logger;

        private readonly string _anonymousRoot;

        private readonly string _userRoot;

        private readonly bool _anonymousRootPerEmail;

        /// <summary>
        /// Initializes a new instance of the <see cref="RootPerUserAccountDirectoryQuery"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="logger">The logger.</param>
        public RootPerUserAccountDirectory(
            IOptions<RootPerUserAccountDirectoryQueryOptions> options,
            ILogger<RootPerUserAccountDirectory> logger = null)
        {
            _logger = logger;
            _anonymousRoot = options.Value.AnonymousRootDirectory ?? string.Empty;
            _userRoot = options.Value.UserRootDirectory ?? string.Empty;
            _anonymousRootPerEmail = options.Value.AnonymousRootPerEmail;
        }

        /// <inheritdoc />
        public IAccountDirectories GetDirectories(IAccountInformation accountInformation)
        {
            if (accountInformation.FtpUser.IsAnonymous())
            {
                return GetAnonymousDirectories(accountInformation.FtpUser);
            }

            var rootPath = Path.Combine(_userRoot, accountInformation.FtpUser.Identity.Name);
            return new GenericAccountDirectories(rootPath);
        }

        private IAccountDirectories GetAnonymousDirectories(ClaimsPrincipal ftpUser)
        {
            var rootPath = _anonymousRoot;
            if (_anonymousRootPerEmail)
            {
                var email = ftpUser.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(email))
                {
                    _logger?.LogWarning("Anonymous root per email is configured, but got anonymous user without email. This anonymous user will see the files of all other anonymous users!");
                }
                else
                {
                    rootPath = Path.Combine(rootPath, email);
                }
            }

            return new GenericAccountDirectories(rootPath);
        }
    }
}
