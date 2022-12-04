// CampCleanup.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <algorithm>
#include <iostream>

#include "FileReader.h"
#include "LineSplitter.h"
#include "Range.h"
#include "RangesContain.h"

int main()
{
    const auto lines = FileReader::Lines("Cleanup.txt");
    std::vector<std::pair<Range, Range>> ranges;
    ranges.reserve(lines.size());
    for (const auto& line : lines)
    {
        ranges.push_back(LineSplitter::Split(line));
    }

    const auto contained = std::ranges::count_if(ranges, [](auto p) {return RangesContain::Contains(p); });
    std::cout << "There were " << contained << " contained pairs";
}
