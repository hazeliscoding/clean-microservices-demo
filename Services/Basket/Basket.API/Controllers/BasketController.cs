using System.Net;
using Basket.Application.Commands;
using Basket.Application.GrpcService;
using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public class BasketController(IMediator mediator, IPublishEndpoint publishEndpoint)
    : ApiController
{
    [HttpGet]
    [Route("[action]/{userName}", Name = "GetBasketByUserName")]
    [ProducesResponseType(typeof(ShoppingCartResponse), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> GetBasket(string userName)
    {
        var query = new GetBasketByUserNameQuery(userName);
        var basket = await mediator.Send(query);
        return Ok(basket);
    }

    [HttpPost("CreateBasket")]
    [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateShoppingCartCommand createShoppingCartCommand)
    {
        var basket = await mediator.Send(createShoppingCartCommand);
        return Ok(basket);
    }

    [HttpDelete]
    [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> DeleteBasket(string userName)
    {
        var command = new DeleteBasketByUserNameCommand(userName);
        return Ok(await mediator.Send(command));
    }

    [Route("[action]")]
    [HttpPost]
    [ProducesResponseType((int) HttpStatusCode.Accepted)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
    {
        // Get existing basket with username
        var query = new GetBasketByUserNameQuery(basketCheckout.UserName);
        var basket = await mediator.Send(query);

        if (basket == null)
        {
            return BadRequest();
        }
        
        var eventMessage = BasketMapper.Mapper.Map<BasketCheckoutEvent>(basketCheckout);
        eventMessage.TotalPrice = basket.TotalPrice;
        
        await publishEndpoint.Publish(eventMessage);
        
        // Remove the basket
        var deleteQuery = new DeleteBasketByUserNameCommand(basketCheckout.UserName);
        await mediator.Send(deleteQuery);
        
        return Accepted();
    }
}