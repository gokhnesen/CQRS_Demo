using Application.Features.Brands.Rules;
using Application.Pipelines.Caching;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>, ICacheRemoverRequest
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public string CacheKey => "";

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetBrands";

        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

            Brand brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();
            await _brandRepository.AddAsync(brand);
            //await _brandRepository.AddAsync(brand);


            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);
            return createdBrandResponse;
        }
    }
}
