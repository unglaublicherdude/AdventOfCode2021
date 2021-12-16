class LanternPhish
    def initialize(path)
        file = File.open(path)
        input = file.read
        @initial_sequence = input.split(",").map(&:to_i)
    end
    
    def initial_sequence=(date)
        @initial_sequence = date
    end

    def initial_sequence
        @initial_sequence
    end

    def fishAfterDays(days)
        sequence = @initial_sequence
        states = [0,0,0,0,0,0,0,0,0]
        day = 0
        sequence.each {|timer| states[timer] = states[timer] + 1 }
        while day < days
            new_states = [0,0,0,0,0,0,0,0,0]
            new_states[8] = states[0]
            new_states[7] = states[8]
            new_states[6] = states[7]+states[0]
            new_states[5] = states[6]
            new_states[4] = states[5]
            new_states[3] = states[4]
            new_states[2] = states[3]
            new_states[1] = states[2]
            new_states[0] = states[1]
            states = new_states
            day = day + 1
        end

        states.map{|number|number}.sum
    end

end
