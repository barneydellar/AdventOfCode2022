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

bool Range::Contains(const Range& other) const
{
    return other.Min() >= Min() && other.Max() <= Max();
}
