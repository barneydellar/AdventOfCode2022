#include "RangesContain.h"

#include "Range.h"

bool RangesContain::Contains(const std::pair<Range, Range> pair)
{
    return pair.first.Contains(pair.second) || pair.second.Contains(pair.first);
}
