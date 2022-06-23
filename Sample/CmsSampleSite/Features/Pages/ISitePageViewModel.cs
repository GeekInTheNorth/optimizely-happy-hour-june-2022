﻿namespace CmsSampleSite.Features.Pages;

public interface ISitePageViewModel<out T>
    where T : ISitePageData
{
    T CurrentPage { get; }
}