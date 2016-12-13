package com.gt.diff.webapp.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonInclude;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@JsonInclude(JsonInclude.Include.NON_NULL)
/**
 * The DiffTask operation holds all the information used by a diff task, including
 * an id to be referenced on API calls and the contents specified by left and right members.
 */
public class DiffTask {
    private int id;
    private DiffTaskItem left;
    private DiffTaskItem right;

    public DiffTask(int id) {
        this.id = id;
    }
}
