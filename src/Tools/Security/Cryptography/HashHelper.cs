namespace Tools.Security.Cryptography
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// The hash helper.
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Generate a random salt.
        /// </summary>
        /// <param name="bitSize">
        /// The bit Size.
        /// </param>
        /// <returns>
        /// The salt.
        /// </returns>
        public static string GenerateRandomSalt(int bitSize = 256)
        {
            // Initialize the random byte generator
            var rngCsp = new RNGCryptoServiceProvider();
            var bytes = new byte[bitSize];

            // Fill the byte array with secure random value
            rngCsp.GetBytes(bytes);

            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        /// <summary>
        /// Generate a random salt.
        /// </summary>
        /// <param name="algorithm">
        /// The algorithm.
        /// </param>
        /// <returns>
        /// The salt.
        /// </returns>
        public static string GenerateRandomSalt(this HashAlgorithm algorithm)
        {
            return GenerateRandomSalt(algorithm.HashSize);
        }

        /// <summary>
        /// Compute the string with the given <paramref name="algorithm"/>
        /// </summary>
        /// <param name="algorithm">
        /// The <see cref="HashAlgorithm"/>.
        /// </param>
        /// <param name="input">
        /// (string) value to get Hash code
        /// </param>
        /// <returns>
        /// (string) Hash value
        /// </returns>
        public static string ComputeHash(this HashAlgorithm algorithm, string input)
        {
            // Convert the input string to a byte array and compute the algorithm.
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Compute the first string with the given <paramref name="algorithm"/> and compare it to <paramref name="hash"/>
        /// </summary>
        /// <param name="algorithm">
        /// The <see cref="HashAlgorithm"/>
        /// </param>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <param name="hash">
        /// The hash to compare.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool VerifyHash(this HashAlgorithm algorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = ComputeHash(algorithm, input);

            // Create a StringComparer an compare the hashes.
            var comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }
    }
}