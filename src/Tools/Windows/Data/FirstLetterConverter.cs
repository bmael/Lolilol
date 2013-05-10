// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FirstLetterConverter.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the FirstLetterConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tools.Windows.Data
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class FirstLetterConverter : IValueConverter
    {
        /// <summary>
        /// Convertit une valeur. 
        /// </summary>
        /// <returns>
        /// Une valeur convertie.Si la méthode retourne null, la valeur Null valide est utilisée.
        /// </returns>
        /// <param name="value">Valeur produite par la source de liaison.</param><param name="targetType">Type de la propriété de cible de liaison.</param><param name="parameter">Paramètre de convertisseur à utiliser.</param><param name="culture">Culture à utiliser dans le convertisseur.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;

            return string.IsNullOrWhiteSpace(s) ? string.Empty : s.Substring(0, 1).ToUpper();
        }

        /// <summary>
        /// Convertit une valeur. 
        /// </summary>
        /// <returns>
        /// Une valeur convertie.Si la méthode retourne null, la valeur Null valide est utilisée.
        /// </returns>
        /// <param name="value">Valeur produite par la cible de liaison.</param><param name="targetType">Type dans lequel convertir.</param><param name="parameter">Paramètre de convertisseur à utiliser.</param><param name="culture">Culture à utiliser dans le convertisseur.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}