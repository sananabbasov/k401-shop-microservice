using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using OrderService.Api.Dtos;
using OrderService.Api.Models;
using OrderService.Api.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateOrderDto createOrderDto)
        {
            var map = _mapper.Map<Order>(createOrderDto);
            _orderRepository.Add(map);
            return Ok();
        }

        [Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;



            var getorder = _orderRepository.GetAll(x=>x.UserId == userId);
            var map = _mapper.Map<List<OrderDto>>(getorder);
            return Ok(map);
        }
    }
}

