#include "StringSplitter.h"

#include <ranges>

std::pair<std::string, std::string> StringSplitter::Split(std::string s, char c)
{
    auto to_string = [](auto&& r) -> std::string {
        const auto data = &*r.begin();
        const auto size = static_cast<std::size_t>(std::ranges::distance(r));

        return std::string{ data, size };
    };

    auto range = s |
        std::ranges::views::split(c) |
        std::ranges::views::transform(to_string);

    auto iter = std::ranges::begin(range);

    return { *iter++, *iter};
}
