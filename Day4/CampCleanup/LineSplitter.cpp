#include "LineSplitter.h"

#include "StringSplitter.h"
#include "Range.h"

std::pair<Range, Range> LineSplitter::Split(const std::string& s)
{
    const auto [first_string, second_string] = StringSplitter::Split(s, ',');
    return { Range{first_string}, Range{second_string} };
}
