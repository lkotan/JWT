using AutoMapper;
using Jwt.Business.Abstract;
using Jwt.Core.Repositories;
using Jwt.Entities;
using Jwt.Core.Models.UserRole;
using Jwt.Utilities.Results.DataResult;
using Jwt.Utilities.Results.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Business.Concrete
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IDataAccessRepository<UserRole> _dal;
        private readonly IMapper _mapper;
        public UserRoleService(IDataAccessRepository<UserRole> dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<IDataResponse<int>> DeleteAsync(int id)
        {
            var entity = await _dal.GetAsync(id);
            return await _dal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<IDataResponse<int>>> DeleteRangeAsync(IEnumerable<int> list)
        {
            var result = new List<IDataResponse<int>>();
            foreach (var item in list)
            {
                result.Add(await DeleteAsync(item));
            }
            return result;
        }

        public async Task<IEnumerable<UserRoleListModel>> GetAllAsync()
        {
            return _mapper.Map<List<UserRoleListModel>>(await _dal.TableNoTracking.ToListAsync());
        }

        public async Task<UserRoleModel> GetAsync(int id)
        {
            return _mapper.Map<UserRoleModel>(await _dal.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IDataResponse<int>> InsertAsync(UserRoleModel model)
        {
            return await _dal.InsertAsync(_mapper.Map<UserRole>(model));
        }

        public async Task<IResponse> UpdateAsync(UserRoleModel model)
        {
            return await _dal.UpdateAsync(_mapper.Map<UserRole>(model));
        }
    }
}
