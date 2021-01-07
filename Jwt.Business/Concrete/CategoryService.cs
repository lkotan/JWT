﻿using AutoMapper;
using Jwt.Business.Abstract;
using Jwt.Core.Aspects.Security;
using Jwt.Core.Repositories;
using Jwt.Entities;
using Jwt.Models.Category;
using Jwt.Utilities.Results.DataResult;
using Jwt.Utilities.Results.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Business.Concrete
{
    [SecurityAspect]
    public class CategoryService : ICategoryService
    {
        private readonly IDataAccessRepository<Category> _dal;
        private readonly IMapper _mapper;
        public CategoryService(IDataAccessRepository<Category> dal, IMapper mapper)
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

        public async Task<IEnumerable<CategoryListModel>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryListModel>>(await _dal.TableNoTracking.ToListAsync());
        }

        public async Task<CategoryModel> GetAsync(int id)
        {
            return _mapper.Map<CategoryModel>(await _dal.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IDataResponse<int>> InsertAsync(CategoryModel model)
        {
            return await _dal.InsertAsync(_mapper.Map<Category>(model));
        }

        public async Task<IResponse> UpdateAsync(CategoryModel model)
        {
            return await _dal.UpdateAsync(_mapper.Map<Category>(model));
        }
    }
}
