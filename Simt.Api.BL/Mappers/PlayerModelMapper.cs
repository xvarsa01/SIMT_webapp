using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.enums;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class PlayerModelMapper (ServiceModelMapper serviceModelMapper) : ModelMapperBase<PlayerEntity, PlayerListModel, PlayerDetailModel, PlayerCreationModel>
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
    public override PlayerDetailModel MapToDetailModel(PlayerEntity? entity)
    {
        if (entity == null)
        {
            return PlayerDetailModel.Empty;
        }

        return new PlayerDetailModel
        {
            Id = entity.Id,
            GoldVersionExpiration = entity.GoldVersionExpiration,
            Nick = entity.Nick,
            Email = entity.Email,
            ProfileName = entity.ProfileName,
            ProfileCity = entity.ProfileCity,
            ProfileWeb = entity.ProfileWeb,
            BirthYear = entity.BirthYear,
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
            Fullscreen = entity.Fullscreen,
            AdvancedControl = entity.AdvancedControl,
            DisplayResolution = entity.DisplayResolution,
            TrafficLevel = entity.TrafficLevel,
            VisibilityLength = entity.VisibilityLength,
            FavouriteVehicleId = entity.FavouriteVehicleId ?? Guid.Empty,
            Services = serviceModelMapper.MapToListModel(entity.Services)
                .ToList(),
            ConditionBusId = entity.ConditionBusId,
            ConditionTramId = entity.ConditionTramId,
        };
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


    public override PlayerEntity MapToEntity(PlayerCreationModel model)
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

            GoldVersionExpiration = model.GoldVersionExpiration,
            Email = model.Email,
            BirthYear = model.BirthYear,
            Fullscreen = model.Fullscreen,
            AdvancedControl = model.AdvancedControl,
            TrafficLevel = model.TrafficLevel,
            VisibilityLength = model.VisibilityLength,
            DisplayResolution = model.DisplayResolution,
            ConditionBusId = model.ConditionBusId,
            ConditionBus = null!,
            ConditionTramId = model.ConditionTramId,
            ConditionTram = null!,
        };
    }
}