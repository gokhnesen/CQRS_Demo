﻿using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;

        public CreateBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = new();
            brand.Name = request.Name;
            brand.Id = Guid.NewGuid();
            var result = await _brandRepository.AddAsync(brand);

            CreatedBrandResponse createdBrandResponse = new();

            createdBrandResponse.Id = result.Id;
            createdBrandResponse.Name = result.Name;
            return createdBrandResponse;
        }
    }
}
