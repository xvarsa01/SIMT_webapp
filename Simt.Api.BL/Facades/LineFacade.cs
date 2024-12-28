using Simt.BL.Mappers.InterfaceBase;
using Simt.Common.Models;
using Simt.DAL.entities;
using Simt.DAL.Repositories;

namespace Simt.BL.Facades;

public class LineFacade : FacadeBase<LineRepository, LineEntity, LineListModel, LineDetailModel>
{
    private readonly LineRepository _lineRepository;
    private readonly ModelMapperBase<LineEntity, LineListModel, LineDetailModel> _modelMapper;

    public LineFacade(
        LineRepository repository, 
        ModelMapperBase<LineEntity, LineListModel, LineDetailModel> modelMapper) 
        : base(repository, modelMapper)
    {
        _lineRepository = repository;
        _modelMapper = modelMapper;
    }
}