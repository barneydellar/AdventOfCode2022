#pragma once
#include <string>
#include <utility>

class StringSplitter
{
public:
    static std::pair<std::string, std::string> Split(std::string s, char c);
};

