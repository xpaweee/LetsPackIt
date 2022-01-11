using LetsPackIt.Domain.Consts;
using LetsPackIt.Domain.ValueObjects;

namespace LetsPackIt.Domain.Policies
{
    public record PolicyData(TravelDays Days, Consts.Gender Gender, Temperature Temperature, Localization Localization);
}