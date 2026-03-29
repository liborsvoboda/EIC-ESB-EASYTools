using System.Threading;
using System.Threading.Tasks;

using FubarDev.FtpServer;
using FubarDev.FtpServer.AccountManagement;

using Microsoft.Extensions.Hosting;

namespace EasyITCenter.ServerCoreServers {

    internal class HostedFtpServer : IHostedService {
        private readonly IFtpServerHost _ftpServerHost;

        /// <summary>
        /// Initializes a new instance of the <see cref="HostedFtpServer"/> class.
        /// </summary>
        /// <param name="ftpServerHost">The FTP server host that gets wrapped as a hosted service.</param>
        public HostedFtpServer(
            IFtpServerHost ftpServerHost) {
            _ftpServerHost = ftpServerHost;
        }

        /// <inheritdoc/>
        public Task StartAsync(CancellationToken cancellationToken) {
            return _ftpServerHost.StartAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task StopAsync(CancellationToken cancellationToken) {
            return _ftpServerHost.StopAsync(cancellationToken);
        }
    }

    /// <summary>
    /// Custom membership provider for Authentication Validation Actual is Set by UserName and
    /// Password in Database
    /// </summary>
    public class HostedFtpServerMembershipProvider : IMembershipProvider {
        
        /// <summary>
        /// FTP User Validation Its for Open FTP and User Validation
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public MemberValidationResult ValidateUser(string username, string password) {

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {

                return new MemberValidationResult(MemberValidationStatus.AuthenticatedUser, new CustomFtpUser(username));
            }
            
            return new MemberValidationResult(MemberValidationStatus.InvalidLogin);
        }

        /// <summary>
        /// FTP User Validation Async Its for Open FTP and User Validation
        /// </summary>
        /// <param name="username">The user name.</param>
        /// <param name="password">The password.</param>
        /// <returns>The result of the validation.</returns>
        public async Task<MemberValidationResult> ValidateUserAsync(string username, string password) {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {

                return new MemberValidationResult(MemberValidationStatus.AuthenticatedUser, new CustomFtpUser(username));
            }
            return new MemberValidationResult(MemberValidationStatus.InvalidLogin);
        }

        /// <summary>
        /// Custom FTP user implementation
        /// </summary>
        private class CustomFtpUser : IFtpUser {

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomFtpUser"/> instance.
            /// </summary>
            /// <param name="name">The user name</param>
            public CustomFtpUser(string name) {
                Name = name;
            }
            
            /// <inheritdoc/>
            public string Name { get; }

            /// <inheritdoc/>
            public bool IsInGroup(string groupName) {
                // We claim that the user is in both the "user" group and in the a group with the
                // same name as the user name.
                return groupName == "user" || groupName == Name;
            }
        }
    }
}
