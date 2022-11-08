Week One

# Functional Requirements

-   A user shall be able to give a local repository path as parameter
    input

-   The program shall be able to run in two modes (frequency & author
    mode)

-   When in frequency mode, the program shall be able to produce a
    textual output that lists a number of commits per day

-   When in author mode, the program shall be able to produce a textual
    output that lists a number of commits per day per author

# Non-Functional Requirements

-   When given a repository path, the program shall collect data from
    all the commits with the libgit2sharp library

-----------

Week Two

# Functional Requirements

-   No functional requirements for this week


# Non-Functional Requirements

 -   The database has to store information about which repository were analyzed at which state.
 -   If the repository information exsits in the database, the repository has to be re-analyzed and the information has to be updated to the latest information.
 -   If the repository is re-analyzed and the information corresponds to existing information in the database, the analysis step should be skipped
