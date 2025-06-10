using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Application.Dtos.LoginResponseDto;

public class LoginResponseDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; } = null;
    public string TokenType { get; set; }
    public int ExpiresInMinutes { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}
