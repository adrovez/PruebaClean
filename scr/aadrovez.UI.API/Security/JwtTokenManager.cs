using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace aadrovez.UI.API.Security
{
    public class JwtTokenManager
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly SymmetricSecurityKey _signingKey;

        public JwtTokenManager(string secretKey, string issuer, string audience)
        {
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                throw new ArgumentException("El secreto JWT es requerido.", nameof(secretKey));
            }

            _issuer = issuer;
            _audience = audience;
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }

        public static JwtTokenManager FromConfig(
            string secretKeySetting = "JwtSecret",
            string issuerSetting = "JwtIssuer",
            string audienceSetting = "JwtAudience")
        {
            var secret = ConfigurationManager.AppSettings[secretKeySetting];
            var issuer = ConfigurationManager.AppSettings[issuerSetting];
            var audience = ConfigurationManager.AppSettings[audienceSetting];

            return new JwtTokenManager(secret, issuer, audience);
        }

        public string GenerarToken(string subject, IEnumerable<Claim> extraClaims = null, int expiracionMinutos = 60)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentException("El subject es requerido.", nameof(subject));
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            if (extraClaims != null)
            {
                claims.AddRange(extraClaims);
            }

            var credentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(expiracionMinutos),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal ValidarToken(string token, bool validarLifetime = true)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("El token es requerido.", nameof(token));
            }

            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = !string.IsNullOrWhiteSpace(_issuer),
                ValidIssuer = _issuer,
                ValidateAudience = !string.IsNullOrWhiteSpace(_audience),
                ValidAudience = _audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,
                ValidateLifetime = validarLifetime,
                ClockSkew = TimeSpan.FromMinutes(2)
            };

            var handler = new JwtSecurityTokenHandler();
            return handler.ValidateToken(token, parameters, out _);
        }
    }
}