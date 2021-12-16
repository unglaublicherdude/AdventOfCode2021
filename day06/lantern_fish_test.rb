require_relative "lantern_fish"
require "test/unit"
 
class TestLanternPhish < Test::Unit::TestCase
 
  def test_part_one_parsing
    assert_equal(3, LanternPhish.new("input_test").initial_sequence[0])
    assert_equal(1, LanternPhish.new("input_test").initial_sequence[3])
  end

  def test_part_one_count_fish_after_18_days
    assert_equal(26, LanternPhish.new("input_test").fishAfterDays(18))
  end
 
end