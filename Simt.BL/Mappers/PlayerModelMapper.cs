using Simt.BL.Mappers.InterfaceBase;
using Simt.Common.enums;
using Simt.Common.Models;
using Simt.DAL.entities;

namespace Simt.BL.Mappers;

public class PlayerModelMapper : ModelMapperBase<PlayerEntity, PlayerListModel, PlayerProfileModel>
{
    public override PlayerListModel MapToListModel(PlayerEntity? entity)
    {
        if (entity == null)
        {
            return PlayerListModel.Empty;
        }

        return new PlayerListModel
        {
            Id = entity.Id,
            Nick = entity.Nick,
            ProfileName = entity.ProfileName,
            ProfileCity = entity.ProfileCity,
        };
    }
    public override PlayerProfileModel MapToDetailModel(PlayerEntity? entity)
    {
        throw new NotImplementedException();
    }
    
    public PlayerProfileModel MapToProfileModel(PlayerEntity? entity)
    {
        if (entity == null)
        {
            return PlayerProfileModel.Empty;
        }

        return new PlayerProfileModel
        {
            Id = entity.Id,
            Nick = entity.Nick,
            ProfileName = entity.ProfileName,
            ProfileCity = entity.ProfileCity,
            ProfileWeb = entity.ProfileWeb,
            MyStatus = entity.MyStatus,
            RegistrationDate = entity.RegistrationDate,
            LastLogin = entity.LastLogin,
            PlayTime = entity.PlayTime,
            PassengersCarried = entity.PassengersCarried,
            PointsGained = entity.PointsGained,
            GameMoney = entity.GameMoney,
            Fuel = entity.Fuel,
            Cng = entity.Cng,
            ServiceSpending = entity.ServiceSpending,
            KmOverall = entity.KmOverall,
            KmYear = entity.KmYear,
            KmBus = entity.KmBus,
            KmTBus = entity.KmTBus,
            KmTram = entity.KmTram,
        };
    }


    public override PlayerEntity MapToEntity(PlayerProfileModel model)
    {
        return new PlayerEntity
        {
            Id = model.Id,
            Nick = model.Nick,
            ProfileName = model.ProfileName,
            ProfileCity = model.ProfileCity,
            ProfileWeb = model.ProfileWeb,
            MyStatus = model.MyStatus,
            RegistrationDate = model.RegistrationDate,
            LastLogin = model.LastLogin,
            PlayTime = model.PlayTime,
            PassengersCarried = model.PassengersCarried,
            PointsGained = model.PointsGained,
            GameMoney = model.GameMoney,
            Fuel = model.Fuel,
            Cng = model.Cng,
            ServiceSpending = model.ServiceSpending,
            KmOverall = model.KmOverall,
            KmYear = model.KmYear,
            KmBus = model.KmBus,
            KmTBus = model.KmTBus,
            KmTram = model.KmTram,
            
            GoldVersionExpiration = default,
            Email = string.Empty,
            BirthYear = 0,
            Fullscreen = false,
            AdvancedControl = false,
            DisplayResolution = DisplayResolution.Res1920X1080,
        };
    }
}