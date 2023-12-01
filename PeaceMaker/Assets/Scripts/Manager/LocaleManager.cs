using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleManager : Singleton<LocaleManager>
{
    bool isChanging;
    public int curLocale = 2;
    public void ChangeLocale(int index)
    {
        if(isChanging)
        {
            return;
        }
        StartCoroutine(ChangeRoutine(index));
        curLocale = index;
    }

    IEnumerator ChangeRoutine(int _index)
    {
        isChanging = true;

        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_index];
        isChanging = false;
    }
}
