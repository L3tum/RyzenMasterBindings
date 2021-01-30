cmake_minimum_required(VERSION 3.17)
project(RyzenMasterWrapper)

set(CMAKE_CXX_STANDARD 14)

SET(OBJS external/ryzenmasterlibs/Device.lib external/ryzenmasterlibs/Platform.lib)

SET_SOURCE_FILES_PROPERTIES(
        ${OBJS}
        PROPERTIES
        EXTERNAL_OBJECT true
        GENERATED true
)

set(RM_SDK_HEADERS external/ryzenmasterinclude/IPlatform.h)
add_library(RyzenMasterWrapper SHARED library.cpp library.h ${RM_SDK_HEADERS} ${OBJS})
target_include_directories(RyzenMasterWrapper PRIVATE external/ryzenmasterinclude)

set_target_properties(RyzenMasterWrapper PROPERTIES LINK_FLAGS /MACHINE:X64)

add_custom_command(TARGET RyzenMasterWrapper POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy_if_different
        "${PROJECT_SOURCE_DIR}/cmake-build-$<CONFIGURATION>/RyzenMasterWrapper.dll"
        "${PROJECT_SOURCE_DIR}/../RyzenMasterBindings/RyzenMasterWrapper.dll")
