﻿using System;
using System.Text;

namespace Binarysharp.MemoryManagement.Helpers
{
    /// <summary>
    ///     Static helper class providing tools for generating random numbers or strings.
    /// </summary>
    public static class Randomizer
    {
        #region Fields

        /// <summary>
        ///     Allowed characters in random strings.
        /// </summary>
        static readonly char[] AllowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        /// <summary>
        ///     Provides random engine.
        /// </summary>
        static readonly Random Random = new Random();

        #endregion Fields

        #region GenerateNumber

        /// <summary>
        ///     Returns a random number within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">
        ///     The exclusive upper bound of the random number returned. maxValue must be greater than or equal
        ///     to minValue.
        /// </param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue.</returns>
        public static int GenerateNumber(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }

        /// <summary>
        ///     Returns a nonnegative random number less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">
        ///     The exclusive upper bound of the random number to be generated. maxValue must be greater than or
        ///     equal to zero.
        /// </param>
        /// <returns>A 32-bit signed integer greater than or equal to zero, and less than maxValue.</returns>
        public static int GenerateNumber(int maxValue)
        {
            return Random.Next(maxValue);
        }

        /// <summary>
        ///     Returns a nonnegative random number.
        /// </summary>
        /// <returns>A 32-bit signed integer greater than or equal to zero and less than <see cref="int.MaxValue" />.</returns>
        public static int GenerateNumber()
        {
            return Random.Next();
        }

        #endregion GenerateNumber

        #region GenerateString

        /// <summary>
        ///     Returns a random string where its size is within a specified range.
        /// </summary>
        /// <param name="minSize">The inclusive lower bound of the size of the string returned.</param>
        /// <param name="maxSize">The exclusive upper bound of the size of the string returned.</param>
        /// <returns></returns>
        public static string GenerateString(int minSize = 40, int maxSize = 40)
        {
            // Create the string builder with a specific capacity
            var builder = new StringBuilder(GenerateNumber(minSize, maxSize));

            // Fill the string builder
            for (var i = 0; i < builder.Capacity; i++)
            {
                builder.Append(AllowedChars[GenerateNumber(AllowedChars.Length - 1)]);
            }
            return builder.ToString();
        }

        #endregion GenerateString

        #region GenerateGuid

        /// <summary>
        ///     Initializes a new instance of the <see cref="Guid" /> structure.
        /// </summary>
        /// <returns>A new <see cref="Guid" /> object.</returns>
        public static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }

        #endregion GenerateGuid
    }
}