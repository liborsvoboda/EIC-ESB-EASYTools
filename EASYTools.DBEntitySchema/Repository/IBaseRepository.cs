using EASYTools.DBEntitySchema.Core.Entities;
using System.Collections.Generic;

namespace EASYTools.DBEntitySchema.Core.Repository {

    public interface IBaseRepository {

        public List<RelationEntity> GetAll();
    }
}