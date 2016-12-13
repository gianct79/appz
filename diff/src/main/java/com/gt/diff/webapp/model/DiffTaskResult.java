package com.gt.diff.webapp.model;

import com.fasterxml.jackson.annotation.JsonInclude;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Map;

@Data
@NoArgsConstructor
@JsonInclude(JsonInclude.Include.NON_NULL)
/**
 * The DiffTaskResult class contains the result of a DiffTask operation. It contains a result message
 * telling if the DiffTaskItem contents are the same, if the size is different or contents are different.
 * In this case, a diff map containing the offset + length is returned.
 */
public class DiffTaskResult {
    public String result;
    public Map<Integer, Integer> diffs;
}
