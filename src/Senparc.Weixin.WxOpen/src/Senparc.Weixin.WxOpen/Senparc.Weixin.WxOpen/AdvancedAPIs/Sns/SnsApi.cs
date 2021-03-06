﻿/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc
    
    文件名：SnsApi.cs
    文件功能描述：小程序Sns下接口
    
    创建标识：Senparc - 20170105
----------------------------------------------------------------*/

using System;
using System.IO;
using System.Threading.Tasks;
using Senparc.Weixin.Entities;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.WxOpen.AdvancedAPIs.Template.TemplateJson;

namespace Senparc.Weixin.WxOpen.AdvancedAPIs.Sns
{
    /* 
    tip：通过该接口，仅能生成已发布的小程序的二维码。
    tip：可以在开发者工具预览时生成开发版的带参二维码。
    tip：带参二维码只有 10000 个，请谨慎调用。
    */

    /// <summary>
    /// WxApp接口
    /// </summary>
    public static class SnsApi
    {
        #region 同步请求

        /// <summary>
        /// code 换取 session_key
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <param name="jsCode"></param>
        /// <param name="grantType">保持默认：authorization_code</param>
        /// <param name="timeOut">请求超时时间</param>
        /// <returns></returns>
        public static JsCode2JsonResult JsCode2Json(string appId, string secret, string jsCode, string grantType = "authorization_code", int timeOut = Config.TIME_OUT)
        {
            const string urlFormat =
                "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}";

            var url = string.Format(urlFormat, appId, secret, jsCode, grantType);

            var result = Get.GetJson<JsCode2JsonResult>(url);
            return result;
        }

        #endregion

        #region 异步请求

        /// <summary>
        /// 【异步方法】code 换取 session_key
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <param name="jsCode"></param>
        /// <param name="grantType">保持默认：authorization_code</param>
        /// <param name="timeOut">请求超时时间</param>
        /// <returns></returns>
        public static async Task<JsCode2JsonResult> JsCode2JsonAsync(string appId, string secret, string jsCode, string grantType = "authorization_code", int timeOut = Config.TIME_OUT)
        {
            const string urlFormat =
                "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}";

            var url = string.Format(urlFormat, appId, secret, jsCode, grantType);

            var result = await Get.GetJsonAsync<JsCode2JsonResult>(url);
            return result;
        }

        #endregion
    }
}