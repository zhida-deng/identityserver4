using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WXApi.Model
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {

                new ApiResource("api","UsersApi")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResourceResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(), //必须要添加，否则报无效的scope错误
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {

            return new List<Client>
           {
               new Client(){
                   ClientId="client",//指定clientid
                   AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,//授权模式
                   AccessTokenLifetime=5,//token 过期时间
                   ClientSecrets={
                       new Secret("secrect".Sha256())
                   },
                   AllowedScopes={ "api",IdentityServerConstants.StandardScopes.OpenId, //必须要添加，否则报forbidden错误
                  IdentityServerConstants.StandardScopes.Profile}//允许访问的api资源,指上面配置的api
               }
           };
        }



    }
}
