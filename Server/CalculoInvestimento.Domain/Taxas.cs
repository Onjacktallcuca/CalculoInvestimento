
using System;
using System.Configuration;

namespace CalculoInvestimento.Domain
{

    
    public class Taxas
    {
        /// <summary>
        /// Para cálculo do imposto utilizar a seguinte tabela:
        ///         i.Até 06 meses: 22,5%
        ///         ii.Até 12 meses: 20%
        ///         iii.Até 24 meses 17,5%
        ///         iv.Acima de 24 meses 15%
        /// </summary>
        public const double SEMESTRAL = 0.225;
        public const double ANUAL = 0.20;
        public const double BIENAL = 0.175;
        public const double ACIMABIENAL = 0.15;

        /// <summary>
        /// Para medida do Exercício considerar os valores abaixo como fixos:
        ///          i.TB – 108%
        ///          ii.CDI – 0,9%
        /// </summary>
        public const double CDI = 0.009;
        public const double TB = 1.08;
        public const double RATE = CDI * TB;

        #region Tests
        public const int MESES = 12;
        public const double VALOR = 100.52;
        #endregion

        /*
        public static double SEMESTRAL = Convert.ToDouble(ConfigurationManager.AppSettings.Get("SEMESTRAL"));
        public static double ANUAL = Convert.ToDouble(ConfigurationManager.AppSettings.Get("ANUAL"));
        public static double BIENAL = Convert.ToDouble(ConfigurationManager.AppSettings.Get("BIENAL"));
        public static double ACIMABIENAL = Convert.ToDouble(ConfigurationManager.AppSettings.Get("ACIMABIENAL"));

        public static double CDI = Convert.ToDouble(ConfigurationManager.AppSettings.Get("CDI"));
        public static double TB = Convert.ToDouble(ConfigurationManager.AppSettings.Get("TB"));
        */
    }
}
