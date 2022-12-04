#pragma once
#include <utility>

class Range;

class RangesContain
{
public:
    static bool Contains(std::pair<Range, Range> pair);
};

