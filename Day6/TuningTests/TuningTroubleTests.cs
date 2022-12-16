using FluentAssertions;
using Tuning;

namespace TuningTests;

public class TuningTroubleTests
{
    [Test]
    public void TuningTroubleCanBeCreated()
    {
        var t = new TuningTrouble();
    }
    
    [Test]
    public void TuningTroubleTakesInAString()
    {
        var t = new TuningTrouble();
        t.Process("abc");
    }
    
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    [TestCase("zdrrgvvntvtzzssgcgqqbvqqzmqmrrprjjpmpwpvpqpwppfqqnvvjbjcbbrnnvwnvnqnncvvqnvqvmmdzdrzzjmmfzmztzczzjpjllgzgnzgznzpzhhvppmjjtbjbjgbjjpfphfhthpprbbzzhbzzvjjsttjwtjwjllzplzlhlqlfqfvflfvlvqvqsshccgffvzzqllpjllcqcpqcpqccbgcccvwvlldclcppcggjhhtbhbrbwbllldndhnnmnmcccvfvtftrfttlhttgltlflgflfrrftrtrgrmggbccnvccvssbmsmnsmszmmsbshbhpbhhtccnmngmnnntznttwnnmffdccrhrshhzhszslzlqqqsqhhrrvmrrhrmhrrdppshpssjhhhtzhzpzzzbrrqqhhtltgltgghlhpphmmbllczcgcrgcrcmmdjdvdssdbsshqqrprhrfrqrlldggpglplqlgqqvfqqwhqqclcwwbrbwbzzmcczqqpzpzhpzprrsbsfsgscsvsdsnntssgzsgzzdpdmmvnnnnfgngnqntnqnhqnhnrrdvrdvvhcvhcvvmffmccdndhhpghgwwdpwwsbwwwcpchcmmznnvtvfffzgffmfdmdsdrrsjjblbglgrrnllzrlrnnrzztnnnqlnlhnllnflllvjjdpdnngfnnlzlrzllrnlnznszzhhvggbqqcmqqvhqhhzfznnhthlhfllqwwghwgwnnnrcchffqnqjjmhjmjsjrjjrwjrrhbhfbhffprprhrddscddbbrzrvrcclttppvrvrlrplpffdwffwrwvvmssgjjbttpgpfplffgfwfnnmhhwghhpfptprtrzzwlwnwmwzzbmbrrdjrjzjpzpggftffglgzzdgzgbbzwzrrdzdhdbhhfppvrvrrrshrrzwwhjwwtjjhbhgbbhjhmmcvvchcfczfcffgttzbzssdqqjwjbbhthgthghthghmhlmmjwmwccfftnnddlffntnhtnhhnnldlhlthhqvhqvhhcgclcmmcnnwnqqzgzczccftfzfrrnhnjhhnlljdjhjghhchvchvchcphpnnnznhnjjlmjlmlbmmsbmbnnmqmvmhhcrcvvqffjpjzpjzjnnhsnhsslqlqvqzzmffdtfdffjrfjrjcjzjnjfjdfjfvjvddtntcttcwcqwqlqjqlqrrzccsgsgffwddrldrrhlllgppghphddqttdwtwnwlnlccmwwfnngvnvddwvwttjjsgghcchjjnvnccjljcljcljjjrttdstsmsggdbdbnddqpddbqqpbpdpgdpdnpnbnffcfrfrfhfcfgcfgcffvjvccgscshhvthvthtbhtbbmppjjrjqrjqjmjzjjjvffmbbfppndngnrnsnnmbbcmcddfzdfzdffqssfwsfwwpzpfpmpqpjqjwqqzwqwvvsddvrrdsrszrrrjqrjjqtqftthhmpmhpmhphggjsggjpppmhmzzdllcscpsswsqqjsqsvvlffmwgtmbthswfqqppsdflzhmdbcnzgdrlzccsdtptgmhfhwtbwqdhptvsvgdfdsmvsrtjjthchmbrjpmrwhgrdllphnfhrfdlgqmbrtdwcmcbphrzthflcswnhqmfhwprbgczbmsmjvbwjftgfqhbhqgzsvcpplzgctzggfljbmhsmwcwltllqgqtvhlbnpzpccbsbhpvhttdjvcnbqhlccdcclwfvcqnttlzzhqpltnnzzlnwtgppwfvmjhtmlzbzdrgbpbbmwlczdwmfhsvpnhpcqwzlnzslncdcqblvlpqfzhhszzrssvhglsllbbmjngfjlpjjvjbzbrlrmwfvzbgtzvcrshtsswhjrjvtwwbrqvtqnndndthfgfcnprpwwtffcvmllngsftrnwnjmwfljjtwnqqmphdlctvdpnsmbrhmljzmfvhcpblmwjjgqvslgslpbjzqzgzpwgssljztmztbwbqlfwrwgvwrjzvpvncqpdspgpzsjnvcrtzpnspvmnvssbgmsbpdsmcvjmtczczzsjcqcfhvcmsbsjfsssvzpvrtmmgptpcsrjslgvclflhjdpwtsmrgjjcftjmjrzrpwqlqvrqjpflbgrfhswbpcnvrrwpzqtzmqjspqqpwlcwgwgclpnwhhrrmzvvnjrjgjfqftlwjrggjgsdfvqhghmshczbbcvrmsgfdqhhmpfzqtbqwsmwfnwfwndjtlntzbbhlzlhrlzgljlmlbcwcdzbctlbqjmfpdwfcfnrbztvlwjhgmfvjcclcrwwwwvqshnfthtcccnswnfzlznlfcmcfrrsjqfvrwjvtbrwggzmdglcbzfdflrdqsjhzcjpghdmwhzrshnqqtsrccbhnlqcsclwmnvjpfqjszwrqnvbgmcdsvhntqmmnrdpbtpqwvhztmtjfvdplgzhhgsrnbwggnwzbtzwcsbrftzhvwtrwvcqrbcnqnrcmbmsvlcfbmzfcvqpwsmmfdgssnhghwjlsslmgnrqgpmbhpqzfnvztsjzjqgrzbbdpvtprwdzdszlhpcgwvdfvhtbtpfjnqnpzwplrwnfdpdclwgnrjlzzshhcchswtzrcmrfpgwjvttqfbbsdnctrtnmwqsmnfsgfgplphcrhglcrnrbzvcfrdfhdtsjmnvfwslcntttqzvhhbljzmpmlsrsblhvmvphppdmjfzwfmflcfwwtdfcndqzgsbrcppsngqfnnjtccnmfjqzhdpnnrqvhrmnrwntqrvmlzfrdszhctzjjdwqrrldtqgrztrvdfrpgprqhqrbnmpfzzlprrpqgtqmzshpcdbwgmrqhrvvgwvspqzmsrvprvsclffwhzlvgfgcsjtmnmthwfmdnfccvlbwbcrlsghhpzcvcnffvccsqjtnhhnbwgfjmqczbrfmjtmmbznspmvtcvdllbgrcvtdzpgzcjzqdjpglhbbnbvwztrdhcrcvrpbshwlmdbmpdgzzflglwgfhvngcgpwshfhzsbrmnhrftmcfqdhnmfmdzbzfgggrzchtzrhgtjpqhdglgdhdqzqpmqmtsbbjjgvtrngdvghwdmgnmdlwsvpmldlsjrtwhltfpbmqlngncwspcptphdppdmjfvtnmdrpbwzrdzcqjdnprpcddjqjhpllsrqzdpcpnplmnmwfqjtnfmnwljbsfgwlgjpwdbbqblvsqcvvgmbrhsqjcscsflcfdzbnrflmrpzhzdhzqhgvmtfjpwtfqnclplgwrjtfvrncjlqtqlrrnjsrvpwbrdcppvnjfzdrzhcltpdfgfndvqtqzvvztgzssdsvvvjwrtjmqcchbjmppqzmgwqdvmmdqbcpbmcnjsvjlwmmnvmnlzdsnsjpldgpjgsbqmpcdsvhdfhgpbggqmrdhbhvvpnzdpqtmldmfqdfchzdfgddzgvcdzgcwjlhnzjwhpwlfwhgjthjshqtzbblhflmsfvtwplfpmpndgjmhndqlhcvfhmjmmqgnjstrzqvshzbbsfqwszwccmrcjnmlsplqzwrgrcwqbmrfwljmlqtqztscrhgjdqzhvmhncvssfznpgrbrjvchsgnjjnnqqrqwsqsrgmltvgtjvpztwmsspjtqdwrbftzrbcmdthmztmnqtmmnffqjjzbvwghrsdmbbjsnnhbdcbqsbcdmwqqppcvsndzbfnsgtpptdftrfthdclqrqvmhnddmjzlnfgscfdwjljjgjnddcrzvclfqbdhprttwpmsnzvdgzwmnzznpqhlhhslwgzlczlgvbjbgqdczztzjnswphllncbsqdmbsbqqsltzmmhmhfnngbttvdsmfrpgthwpfdhsstrjssghlrrlhbmgdsvhzvlhhfvtcrrhlndgrjjcgmjwgnjtlmpmzgqgpnpsvlnthgrvsdfcnmzmthqzfpjdqjbhgmjqsqvvdldrgqwlghdlwqdbfmffgvzmptqhnvbrdbqtcjmsdnjljpbrtcvvnffvztbwfnmtvdbnshlbgvbnljntlrldbwqvqmblnvhwtw", 2315)]
    public void TuningTroubleSaysWhereTheFirstMarkerOccurs(string input, int marker)
    {
        var t = new TuningTrouble();
        t.Process(input);
        t.FirstMarker.Should().Be(marker);
    }
    
    
    [TestCase("abcdefghijklmn", new string[]{"abcdefghijklmn"})]
    [TestCase("abcdefghijklmno", new string[]{"abcdefghijklmn", "bcdefghijklmno"})]
    [TestCase("abcdefghijklmnop", new string[]{"abcdefghijklmn", "bcdefghijklmno", "cdefghijklmnop"})]
    public void CanFindGroupsOfFourteen(string input, string[] strings)
    {
        var t = new TuningTrouble();
        var groups = t.Groups(input);
        groups.Length.Should().Be(strings.Length);
        for (var i = 0; i < groups.Length; i++)
        {
            groups[i].Should().Be(strings[i]);
        }
    }
    
    [TestCase("abcd", true)]
    [TestCase("abca", false)]
    [TestCase("xxyz", false)]
    public void CanTellIfAGroupHasAllUniqueCharacters(string input, bool expected)
    {
        var t = new TuningTrouble();
        t.AllUnique(input).Should().Be(expected);
    }
}