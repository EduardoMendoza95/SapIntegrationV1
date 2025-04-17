namespace Wee.SapIntegration.Application.Features.Autenticacion.Dtos
{
    public class TokenResponseDto
    {
       

        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string TokenType { get; set; }
    }
}