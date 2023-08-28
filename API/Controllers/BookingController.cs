//
//
// using HotelApp.Data.Repositories;
// using HotelApp.Models;
// using HotelApp.Models.Enums;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace HotelWebAPI.Controllers;
//
//
// [Route("api/[controller]")]
// [ApiController]
// public class BookingController : ControllerBase
// {
//     // private readonly IBookingService _bookingService;
//     // private readonly IUserService _userService;
//     // private readonly IEmailService _emailService;
//
//
//
//     // public BookingController(IBookingService bookingService, IUserService userService,IEmailService emailService)
//     // {
//     //     _bookingService = bookingService;
//     //     _userService = userService;
//     //     _emailService = emailService;
//     //
//     // }
//     
//     
//     // [HttpGet]
//     // public  IActionResult  GetCurrentBookingList()
//     // {
//     //     var jwt = Request.Cookies["token"];
//     //
//     //     if (jwt == null)
//     //     {
//     //         return Ok("No cookie");
//     //     }
//     //
//     //     var token = _userService.Verify(jwt);
//     //     
//     //     var userEmail = token.Issuer;
//     //     
//     //
//     //     var user = _userService.emailExists(userEmail);
//     //     if (user.roleType != Role.admin)
//     //     {
//     //         return Unauthorized();
//     //     }
//     //     var bookings = _bookingService.GetCurrentBookingList();
//     //     return Ok(bookings) ;
//     // }
//     //
//     //
//     // [HttpGet("/userlist/{id}")]
//     // public IActionResult  GetBookingListByUserId(Guid id)
//     // {
//     //     
//     //     var jwt = Request.Cookies["token"];
//     //
//     //     if (jwt == null)
//     //     {
//     //         return Ok("No cookie");
//     //     }
//     //
//     //     var token = _userService.Verify(jwt);
//     //     
//     //     var userEmail = token.Issuer;
//     //     
//     //
//     //     var user = _userService.emailExists(userEmail);
//     //     if (user.roleType != Role.user && user.roleType != Role.admin)
//     //     {
//     //         return Unauthorized();
//     //     }
//     //     return  Ok(_bookingService.GetCurrentBookingListByUserId(id));
//     // }
//     //
//     // [HttpGet("/userlist/past/{id}")]
//     // public IActionResult  GetPastBookingListByUserId(Guid id)
//     // {
//     //     var jwt = Request.Cookies["token"];
//     //     
//     //     if (jwt == null)
//     //     {
//     //         return Ok("No cookie");
//     //     }
//     //     var token = _userService.Verify(jwt);
//     //     
//     //     var userEmail = token.Issuer;
//     //     
//     //     var user = _userService.emailExists(userEmail);
//     //     if (user.roleType != Role.user && user.roleType != Role.admin)
//     //     {
//     //         return Unauthorized();
//     //     }
//     //     return  Ok(_bookingService.GetPastBookingListByUserId(id));
//     // }
//     //
//     //
//     // [HttpGet("/past")]
//     // public IActionResult  GetPastBookings()
//     // {
//     //     var jwt = Request.Cookies["token"];
//     //
//     //     if (jwt == null)
//     //     {
//     //         return Ok("No cookie");
//     //     }
//     //
//     //     var token = _userService.Verify(jwt);
//     //     
//     //     var userEmail = token.Issuer;
//     //     
//     //
//     //     var user = _userService.emailExists(userEmail);
//     //     if (user.roleType != Role.admin)
//     //     {
//     //         return Unauthorized();
//     //     }
//     //     return  Ok(_bookingService.GetPastBookingList());
//     // }
//     //
//     // [HttpGet("{id}")]
//     // public IActionResult  GetBookingById(Guid id)
//     // {
//     //     var jwt = Request.Cookies["token"];
//     //
//     //     if (jwt == null)
//     //     {
//     //         return Ok("No cookie");
//     //     }
//     //
//     //     var token = _userService.Verify(jwt);
//     //     
//     //     var userEmail = token.Issuer;
//     //     
//     //
//     //     var user = _userService.emailExists(userEmail);
//     //     if (user.roleType != Role.user&& user.roleType != Role.admin)
//     //     {
//     //         return Unauthorized();
//     //     }
//     //     
//     //     return  Ok(_bookingService.GetBookingById(id));
//     // }
//     // [HttpPost]
//     // public IActionResult PostBooking([FromBody] BookingDto booking)
//     // {
//     //     var jwt = Request.Cookies["token"];
//     //
//     //     if (jwt == null)
//     //     {
//     //         return Ok("No cookie");
//     //     }
//     //
//     //     var token = _userService.Verify(jwt);
//     //     
//     //     var userEmail = token.Issuer;
//     //     
//     //
//     //     var user = _userService.emailExists(userEmail);
//     //     if (user.roleType != Role.user && user.roleType != Role.admin)
//     //     {
//     //         return Unauthorized();
//     //     }
//     //     
//     //     if (booking.DateOut < DateTime.Now)
//     //     {
//     //         return Ok("Same date");
//     //     }
//     //     var newBooking =  _bookingService.CreateBooking(booking);
//     //     // Email object here 
//     //     return Ok(newBooking);
//     // }
//     //
//     // [HttpPut ("{id}")]
//     // public IActionResult PutBooking(Guid id, [FromBody] EditBookingRequestModel booking)
//     // {
//     //     
//     //     var jwt = Request.Cookies["token"];
//     //
//     //     if (jwt == null)
//     //     {
//     //         return Ok("No cookie");
//     //     }
//     //
//     //     var token = _userService.Verify(jwt);
//     //     
//     //     var userEmail = token.Issuer;
//     //     
//     //
//     //     var user = _userService.emailExists(userEmail);
//     //     if (user.roleType != Role.user && user.roleType != Role.admin)
//     //     {
//     //         return Unauthorized();
//     //     }
//     //     if (id != booking.BookingId)
//     //     {
//     //         return BadRequest();
//     //     }
//     //
//     //      _bookingService.UpdateBooking(booking);
//     //      // Email object here 
//     //     return NoContent();
//     // }
//     //
//     // [HttpDelete("{id}")]
//     // public async Task<ActionResult> deleteBooking(Guid id)
//     // {
//     //
//     //     
//     //     var jwt = Request.Cookies["token"];
//     //
//     //     if (jwt == null)
//     //     {
//     //         return Ok("No cookie");
//     //     }
//     //
//     //     var token = _userService.Verify(jwt);
//     //     
//     //     var userEmail = token.Issuer;
//     //     
//     //
//     //     var user = _userService.emailExists(userEmail);
//     //     if (user.roleType != Role.user && user.roleType != Role.admin)
//     //     {
//     //         return Unauthorized();
//     //     }
//     //     var bookingToDelete = await _bookingService.GetBookingById(id);
//     //     if (bookingToDelete == null)
//     //         return NotFound();
//     //     
//     //      _bookingService.DeleteBooking(bookingToDelete.BookingId);
//     //      // Email object here 
//     //     return NoContent();
//     // }
//     
// }
