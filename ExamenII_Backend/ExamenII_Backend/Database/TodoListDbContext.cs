using ExamenII_Backend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamenII_Backend.Database
{
    public class TodoListDbContext : IdentityDbContext<IdentityUser>
    {
    }
}
