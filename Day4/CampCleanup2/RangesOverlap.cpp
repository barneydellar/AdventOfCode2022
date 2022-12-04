#include "RangesOverlap.h"

#include "Range.h"

bool RangesOverlap::Overlap(const std::pair<Range, Range> pair)
{
    return pair.first.Overlaps(pair.second);
}
