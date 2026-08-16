using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Builds a DataTables-style page number list (with first/last and ellipsis) for server-side pagination.
/// </summary>
public class PagerInfo
{
    public int PageNum { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsEllipsis { get; set; }
    public string DisplayText { get; set; }
}

public static class PaginationHelper
{
    public static List<PagerInfo> BuildPages(int currentPage, int totalPages)
    {
        List<PagerInfo> pages = new List<PagerInfo>();
        if (totalPages <= 1) return pages;

        pages.Add(new PagerInfo { PageNum = 1, IsCurrent = currentPage == 1, DisplayText = "1" });

        int start = Math.Max(2, currentPage - 2);
        int end = Math.Min(totalPages - 1, Math.Max(currentPage + 2, 5));

        if (start > 2)
            pages.Add(new PagerInfo { IsEllipsis = true, DisplayText = "..." });

        for (int i = start; i <= end; i++)
            pages.Add(new PagerInfo { PageNum = i, IsCurrent = i == currentPage, DisplayText = i.ToString() });

        if (end < totalPages - 1)
            pages.Add(new PagerInfo { IsEllipsis = true, DisplayText = "..." });

        if (totalPages > 1)
            pages.Add(new PagerInfo { PageNum = totalPages, IsCurrent = currentPage == totalPages, DisplayText = totalPages.ToString() });

        return pages;
    }
}
