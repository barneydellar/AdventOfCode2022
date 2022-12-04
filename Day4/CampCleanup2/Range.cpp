#include "Range.h"

#include <ranges>

#include "StringSplitter.h"

Range::Range(const std::string& s)
{
    const auto [min_str, max_str] = StringSplitter::Split(s, '-');

    min = std::stoi(min_str);
    max = std::stoi(max_str);
}

int Range::Min() const
{
    return min;
}

int Range::Max() const
{
    return max;
}

bool Range::Overlaps(const Range& other) const
{
    if (other.Max() < Min())
    {
        return false;
    }
    if (other.Min() > Max())
    {
        return false;
    }
    return true;
}
