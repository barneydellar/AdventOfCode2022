#pragma once
#include <string>

class Range
{
public:
    Range(const std::string& s);
    int Min() const;
    int Max() const;

    bool Contains(const Range& other) const;

private:
    int min;
    int max;
};

