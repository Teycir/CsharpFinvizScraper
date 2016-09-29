#region

using System;
using System.Collections.Generic;

#endregion

namespace WebScrap.Presenter
{
    public interface IViewMoneyFlow
    {
        bool Email { get; set; }

        bool Tweet { get; set; }

        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <param name="obj"> The obj. </param>
        /// <param name="obj1"> The obj1. </param>
        /// <param name="obj2"> The obj2. </param>
        /// <param name="obj3"> The obj3. </param>
        /// <param name="ticker"> The ticker. </param>
        /// <param name="flowAlertValue"> The flow alert value. </param>
        /// <param name="ratioAlertValue"> The ratio alert value. </param>
        /// <param name="ratioAlertValueNeg"> The ratio alert value neg. </param>
        /// <param name="storedata"> The storedata. </param>
        /// <param name="sound"> The sound. </param>
        /// <param name="activesound"> if set to <c>true</c> [activesound]. </param>
        /// <param name="activemail"> if set to <c>true</c> [activemail]. </param>
        /// <param name="starlabel"> The starlabel. </param>
        void GetWsjData(object obj, object obj1, object obj2, object obj3, string ticker, string flowAlertValue,
                        string ratioAlertValue, string ratioAlertValueNeg, string sound,
                        bool activesound, bool activemail, object starlabel);

        void ViewLabel(object obj, string s);
        void ListboxAddItem(object obj, string data);
        void VisibleLabel(object obj, bool visible);
        void ViewTextBox(object obj, string s);
        void ViewCheckBox(object obj, bool b);

        void GetWsjData(Object labelT1B, Object labelT2B, Object labelT3B, Object labelT4B, Object labelT5B,
                        Object labelT1S, Object labelT2S, Object labelT3S, Object labelT4S, Object labelT5S,
                        Object labelT1BPrice, Object labelT2BPrice, Object labelT3BPrice, Object labelT4BPrice,
                        Object labelT5BPrice,
                        Object labelT1SPrice, Object labelT2SPrice, Object labelT3SPrice, Object labelT4SPrice,
                        Object labelT5SPrice,
                        Object labelT1BBlocks, Object labelT2BBlocks, Object labelT3BBlocks,
                        Object labelT4BBlocks, Object labelT5BBlocks,
                        Object labelT1Slocks, Object labelT2SBlocks, Object labelT3SBlocks, Object labelT4SBlocks,
                        Object labelT5SBlocks,
                        object labelB1BRatio, object labelB2BRatio, object labelB3BRatio, object labelB4BRatio,
                        object labelB5BRatio, object labelS1BRatio, object labelS2BRatio, object labelS3BRatio,
                        object labelS4BRatio, object labelS5BRatio);


        void FillCombobox(object obj, List<string> values);
    }
}