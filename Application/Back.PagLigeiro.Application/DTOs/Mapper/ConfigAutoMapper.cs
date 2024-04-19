using AutoMapper;
using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Domain.Model.User;

namespace Back.PagLigeiro.Application.DTOs.Mapper
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        {
            #region User

            CreateMap<UserCreateRequest, UserModel>();
            CreateMap<UserModel, UserCreateRequest>();

            CreateMap<UserResult, UserModel>();
            CreateMap<UserModel, UserResult>();

            #endregion User
        }
    }
}