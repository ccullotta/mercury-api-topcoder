using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topcoderattempt1
{
    public class Constants
    {
        public const string Issuer = Audiance;
        public const string Audiance = "https://localhost:44394/";
        public const string SecretKey = "not too short secret otherwise it will break and that would suck ";
        public const string googleApiKey = "-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCRj+HNxY91Ds2Q\nlVvBwb0tYf64ZVBrTbq5cfFqhfOlxhqlduORwLXkQkYJFzgjL7DcnE5je/xtB8E5\nQNU6yqBheT30DhsmJVbi7PWRF/oMPXeYO7tLClCbB3aVtO7rZfiVmDdV6Jm1yr8u\nAUQBz2Wu0qk5ZwzOIMvyd6MnK//S6Ef3x/ojyKK1C5AT7ZVSVcG8T0DzNEaYmcEX\nnKeH43kspcsJA+xrBxkf1TtFp7SmkLhRAT1UL6lK9EPVaWj23D3gFTYkEXo0lp1i\ngfIrae99VmHMAQ87l5FYQubRj5Hzqk79PXz5Sg/fJbbZJnJP9Dl5OpbGQWrwZaBJ\nyUakxx8RAgMBAAECggEAB5BX9fbdoQIPaYNxXKyiFXEhqNhO6PyFhuxmVJg4VHVq\nXg3C/ohqiz1sYT2NI7rvME+I/T9smwfLoRt+2Qq9ccM4lm2DOKS5Epqomg0KZ8dr\n5wO3lEspbBzjqxzXS3EljTR3L6YiEqHB9HSJYaSyznZQ59Q0hKOMpYFU/4yYQw/N\n2KmbUjMbuFdHkRAzAvnka42MLIXRRquN75iwwrm4u62s0Z1MAWEy/GR1TaV3qT7c\nLthucS2wuLkqsQD+vEsntWiZ9kUwzGBDRpmKbx28hdRqJ4LESB/6gRPT3QVy2TLC\nDPZo8Esxr2IQHfgEXwhSdq/xaFatJ6yKsfr3hQ4VqQKBgQDE7aQmP7mjFpUOn5LF\nqSmhk7Lvu+jgsOaj+f3ufi99JKZ6BgaNOJ6GlKNMqitN3StiJ3SmGBEG2kVwLlYu\nksYGBZiT6mKnWkdm/bFzucKwNa+FeamsuO+/DHbJFAtNsh31jEU2kKQwBNaj5+kh\nIXJPMBxe9ht7/zbbmwJn0LD8VQKBgQC9OcPopyyVvgkPuvWV8+asjCQ2TIgKMg7a\nk6GgsDYmGQfi5lcebCnGoaNj5/3AE10vi7dEYu+yYhubmURV2EYtlm6y7FtDpOUO\ntopuO4QrNC/TfpYYIqQD+xy+Prb686lY5gQygqXNBClMv2Pa5NyJMxl5mv6xnNMH\nsoX1fcfTzQKBgBLe0sP3h0phd5cXI3FdbGfXR2ZBk2c0jGVaJ0MbRGGxiWJYAXi2\n3Dn5NEy8YbnsX6PgNAVWeQs3D0BYsFl2JxOcpapG43014XG1DbQRMN7Bxjf8GI48\niny8LQXHre2cC9Ljxh4cbh9L12WNa4GJOvLroUxYOPoA0rjoeaqJDOyhAoGBAJ+9\njRnxTp0WsRWbccjl/ly5bbR9BPb+bTWuHWrGdt/Qj6zHYNIo41dwirtDVB56+lax\n7sOHdew0EDRZvatuiUfgz5CyIRVItamnBdOq4JeMVbeIDHNRgv5tVUVxMg1F9zc5\n7l8plYguNCM7CrP2MgqMnbvf0ZTk2+2KkrW8Oh4dAoGAK1fyuoh++ormR+Xer1GL\nVuxZVUNJl1yTgJceXknEWfyiC2y3Y0lrJDl4gBVdJNyzCvufz8eqMjFTvb4h+UmY\nREfhT9/xpNRx4dJ/OsnQ+YpdLldqa51n4PryfJ5n9JTOovmedyltoWRca5Fn8i24\nH7GQIF0d9K5YMFz3AwZXiR8=\n-----END PRIVATE KEY-----\n";
        public const string baseUrl = "https://localhost:44394/";

        public static SigningCredentials signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
            SecurityAlgorithms.HmacSha512);
    }
}
