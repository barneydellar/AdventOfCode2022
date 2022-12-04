#pragma once
#include <string>
#include <utility>

class Range;

class LineSplitter
{
public:
    static std::pair<Range, Range> Split(const std::string& s);
};

