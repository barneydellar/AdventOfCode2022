#pragma once
#include <utility>

class Range;

class RangesOverlap
{
public:
    static bool Overlap(std::pair<Range, Range> pair);
};

