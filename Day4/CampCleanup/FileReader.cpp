#include "FileReader.h"

#include <fstream>
#include <iostream>

std::vector<std::string> FileReader::Lines(const std::string& path)
{
    std::vector<std::string> lines;

    std::ifstream file(path);
    std::string content;

    while (file >> content) {
        lines.push_back(content);
    }
    return lines;
}
