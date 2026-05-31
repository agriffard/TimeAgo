using System.Globalization;
using Microsoft.AspNetCore.Components;
using TimeAgo.Resources;

namespace TimeAgo;

public partial class TimeAgoComponent : IAsyncDisposable
{
    [Parameter]
    [EditorRequired]
    public DateTime Date { get; set; }

    [Parameter]
    public string? Culture { get; set; }

    [Parameter]
    public int UpdateInterval { get; set; } = 30000;

    [Parameter]
    public string? CssClass { get; set; }

    private Timer? _timer;
    private CultureInfo _cultureInfo = CultureInfo.CurrentUICulture;
    private string _relativeText = string.Empty;

    protected override Task OnInitializedAsync()
    {
        _timer = new Timer(async _ =>
        {
            await InvokeAsync(() =>
            {
                UpdateRelativeText();
                StateHasChanged();
            });
        }, null, UpdateInterval, UpdateInterval);

        return Task.CompletedTask;
    }

    protected override void OnParametersSet()
    {
        _cultureInfo = ResolveCulture();
        UpdateRelativeText();
    }

    private CultureInfo ResolveCulture()
    {
        try
        {
            var requestedCulture = string.IsNullOrWhiteSpace(Culture)
                ? CultureInfo.CurrentUICulture
                : new CultureInfo(Culture);

            return requestedCulture.TwoLetterISOLanguageName.ToLowerInvariant() switch
            {
                "fr" => requestedCulture,
                "en" => requestedCulture,
                _ => new CultureInfo("en")
            };
        }
        catch (CultureNotFoundException)
        {
            return new CultureInfo("en");
        }
    }

    private void UpdateRelativeText()
    {
        var diff = DateTime.UtcNow - Date.ToUniversalTime();

        if (diff < TimeSpan.Zero)
        {
            _relativeText = TimeAgoResources.Future(_cultureInfo);
            return;
        }

        if (diff < TimeSpan.FromMinutes(1))
        {
            _relativeText = TimeAgoResources.JustNow(_cultureInfo);
            return;
        }

        if (diff < TimeSpan.FromMinutes(2))
        {
            _relativeText = TimeAgoResources.OneMinuteAgo(_cultureInfo);
            return;
        }

        if (diff < TimeSpan.FromHours(1))
        {
            _relativeText = string.Format(_cultureInfo, TimeAgoResources.MinutesAgo(_cultureInfo), (int)diff.TotalMinutes);
            return;
        }

        if (diff < TimeSpan.FromHours(2))
        {
            _relativeText = TimeAgoResources.OneHourAgo(_cultureInfo);
            return;
        }

        if (diff < TimeSpan.FromHours(24))
        {
            _relativeText = string.Format(_cultureInfo, TimeAgoResources.HoursAgo(_cultureInfo), (int)diff.TotalHours);
            return;
        }

        if (diff < TimeSpan.FromDays(2))
        {
            _relativeText = TimeAgoResources.Yesterday(_cultureInfo);
            return;
        }

        if (diff < TimeSpan.FromDays(30))
        {
            _relativeText = string.Format(_cultureInfo, TimeAgoResources.DaysAgo(_cultureInfo), (int)diff.TotalDays);
            return;
        }

        if (diff < TimeSpan.FromDays(60))
        {
            _relativeText = TimeAgoResources.OneMonthAgo(_cultureInfo);
            return;
        }

        if (diff < TimeSpan.FromDays(365))
        {
            _relativeText = string.Format(_cultureInfo, TimeAgoResources.MonthsAgo(_cultureInfo), (int)(diff.TotalDays / 30));
            return;
        }

        if (diff < TimeSpan.FromDays(730))
        {
            _relativeText = TimeAgoResources.OneYearAgo(_cultureInfo);
            return;
        }

        _relativeText = string.Format(_cultureInfo, TimeAgoResources.YearsAgo(_cultureInfo), (int)(diff.TotalDays / 365));
    }

    public ValueTask DisposeAsync()
    {
        _timer?.Dispose();
        _timer = null;
        return ValueTask.CompletedTask;
    }
}
