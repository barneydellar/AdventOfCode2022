#pragma once
#include <string>
#include <vector>

class FileReader
{
public:
    static std::vector<std::string> Lines(const std::string& path);
};

