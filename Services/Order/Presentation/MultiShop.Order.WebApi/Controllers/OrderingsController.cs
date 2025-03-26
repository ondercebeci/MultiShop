﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderingsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> OrderingList()
		{
			var values =await _mediator.Send(new GetOrderingQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderingById(int id)
		{
			var values = await _mediator.Send(new GetOrderingByIdQuery(id));
			return Ok();
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş Eklendi");

		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOrdering(int id)
		{
			await _mediator.Send(new RemoveOrderingCommand(id));
			return Ok("Sipariş Silindi");

		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş Güncellendi");
		}
	}
}
