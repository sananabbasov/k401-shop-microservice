using System;
using CatalogService.Entities.Dtos.SpecificationDtos;
using K123ShopApp.Core.Utilities.Results.Abstract;

namespace CatalogService.Business.Abstract
{
	public interface ISpecificationService
	{
        IResult CreateSpecifications(int productId, List<SpecificationCreateDto> specifications);
    }
}

