using Application.Features.Dynamic;
using Application.Features.Models.Queries.GetList;
using Application.Features.Paging;
using Application.Features.Requests;
using Application.Features.Responses;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListDynamic
{
    public class GetListDynamicModelQuery : IRequest<GetListResponse<GetListDynamicModelListItemDto>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public class GetListDynamicModelQueryHandler : IRequestHandler<GetListDynamicModelQuery, GetListResponse<GetListDynamicModelListItemDto>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            public GetListDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }
            public async Task<GetListResponse<GetListDynamicModelListItemDto>> Handle(GetListDynamicModelQuery request, CancellationToken cancellationToken)
            {
                Paginate<Model> models = await _modelRepository.GetListyByDynamicAsync(
                    request.DynamicQuery,
                     include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                     index: request.PageRequest.PageIndex,
                     size: request.PageRequest.PageSize
                     );

                var response = _mapper.Map<GetListResponse<GetListDynamicModelListItemDto>>(models);
                return response;
            }
        }
    }
}
