using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace mtsToolsWebAPI.Controllers
{
    /// <summary>
    /// 用户管理中心
    /// </summary>
    public class UsersController : ApiController
    {
        private readonly IGenericRepository<MtsAccountInfo> _userDetailRepository;
        /// <summary>
        /// 用户管理 --- 构造
        /// </summary>
        /// <param name="userDetailRepository"></param>
        public UsersController(IGenericRepository<MtsAccountInfo> userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }
        /// <summary>
        /// 获得用户信息列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IQueryable<MtsAccountInfo> GetUserDetailList()
        {
                return _userDetailRepository.GetAll();
        }
        /// <summary>
        /// 根据用户ID获取用户详细信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        [HttpPost]
        public  MtsAccountInfo GetUserDetailByUserID(string userID)
        {
            MtsAccountInfo mtsAccountInfo = new MtsAccountInfo();
            mtsAccountInfo.UserID = userID;

            ServiceResponse  serviceResponse =  _userDetailRepository.GetModelQuery(mtsAccountInfo);

            List<MtsAccountInfo> mtsAccountInfos = serviceResponse.Results as List<MtsAccountInfo>;
            return mtsAccountInfos.FirstOrDefault();
        }

        /// <summary>
        /// 过滤条件
        /// </summary>
        /// <param name="queryCondition">过滤条件</param>
        /// <returns></returns>
        [HttpPost]
        public List<MtsAccountInfo> GetUserDetailsList(QueryCondition<MtsAccountInfo> queryCondition)
        {
            Expression<Func<QueryCondition<MtsAccountInfo>, bool>> whereQueryCondition = EFExpressionHelper.GenerateFullQueryExpression<QueryCondition<MtsAccountInfo>>(queryCondition);
            return _userDetailRepository.GetAll() as List<MtsAccountInfo>;
        }
    }
}