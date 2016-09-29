using System;
using System.Collections.Generic;

namespace WebScrap.Presenter
{
    public interface IViewMain
    {
        List<string> GetData(object obj, object obj1, object obj2, object obj3, string ticker, string flowAlertValue, string ratioAlertValue, string storedata, string sound, bool activesound, bool activemail, object starlabel);
        void ViewLabel(object obj, string s);
        void VisibleLabel(object obj, bool visible);
        void ViewTextBox(object obj, string s);
        void ViewCheckBox(object obj, bool b);
        string SetTickersState(string ticker1, string ticker2, string ticker3, string ticker4, string ticker5,
                             string ticker6, string ticker7, string ticker8, string ticker9, string ticker10,
                             string ticker1FAlert, string ticker2FAlert, string ticker3FAlert, string ticker4FAlert,
                             string ticker5FAlert,
                             string ticker6FAlert, string ticker7FAlert, string ticker8FAlert, string ticker9FAlert,
                             string ticker10FAlert, 
                             string ticker1RAlert, string ticker2RAlert, string ticker3RAlert,
                             string ticker4RAlert, string ticker5RAlert,
                             string ticker6RAlert, string ticker7RAlert, string ticker8RAlert,
                             string ticker9RAlert, string ticker10RAlert
            );
        void GetTickersState(object ticker1, object ticker2, object ticker3, object ticker4, object ticker5,
                             object ticker6, object ticker7, object ticker8, object ticker9, object ticker10,
                             object ticker1FAlert, object ticker2FAlert, object ticker3FAlert, object ticker4FAlert,
                             object ticker5FAlert,
                             object ticker6FAlert, object ticker7FAlert, object ticker8FAlert, object ticker9FAlert,
                             object ticker10FAlert, 
                             object ticker1RAlert, object ticker2RAlert, object ticker3RAlert,
                             object ticker4RAlert, object ticker5RAlert,
                             object ticker6RAlert, object ticker7RAlert, object ticker8RAlert,
                             object ticker9RAlert, object ticker10RAlert
            );


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
            object labelB1BRatio, object labelB2BRatio,object labelB3BRatio, object labelB4BRatio, object labelB5BRatio ,object labelS1BRatio,object labelS2BRatio, object labelS3BRatio, object labelS4BRatio, object labelS5BRatio);


     

    }
}