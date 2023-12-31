﻿using System;
using AutoMapper;
using CatalogService.Business.Abstract;
using CatalogService.DataAccess.Abstract;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.Dtos.SpecificationDtos;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;

namespace CatalogService.Business.Concrete
{
	public class SpecificationManager : ISpecificationService
	{
        private readonly ISpecificationDal _specificationDal;
        private readonly IMapper _mapper;

        public SpecificationManager(ISpecificationDal specificationDal, IMapper mapper)
        {
            _specificationDal = specificationDal;
            _mapper = mapper;
        }

        public IResult CreateSpecifications(int productId, List<SpecificationCreateDto> specifications)
        {
            var mapper = _mapper.Map<List<Specification>>(specifications);
            _specificationDal.AddSpecifications(productId, mapper);
            return new SuccessResult();
        }
    }
}

